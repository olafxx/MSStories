'use strict';

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    uglify = require('gulp-uglify'),
    sass = require('gulp-sass'),
    autoprefixer = require('autoprefixer'),
    cssnano = require('cssnano'),
    postcss = require('gulp-postcss'),
    stylelint = require('stylelint'),
    reporter = require('postcss-reporter'),
    syntax_scss = require('postcss-scss'),
    focus = require('postcss-focus'),
    rename = require('gulp-rename'),
    gnf = require("gulp-npm-files"),
    pump = require("pump"),
    jshint = require("gulp-jshint"),
    stylish = require("jshint-stylish");

var paths = {
    webroot: './wwwroot/',
    lib: './wwwroot/lib'
};

paths.js = {
    js: paths.webroot + 'js/**/*.js',
    minJs: paths.webroot + 'js/**/*.min.js',
    jsDir: paths.webroot + 'js',
    concatName: 'site.js',
    concat: paths.webroot + 'js/site.js',
    jsFromTs: './Scripts/js',
    jsFromTsFiles: './Scripts/js/**/*.js'
};

paths.css = {
    css: paths.webroot + 'css/**/*.css',
    minCss: paths.webroot + 'css/**/*.min.css',
    concat: paths.webroot + 'css/site.css',
    cssMin: paths.webroot + 'css/site.min.css',
    sass: './Css/**/*.scss',
    normalize: paths.webroot + 'lib/normalize.css/normalize.css',
    cssDir: paths.webroot + 'css'
};

var stylelintConfig = {
    'rules': {
        'color-hex-case': 'lower',
        'font-family-name-quotes': 'always-where-recommended',
        'number-leading-zero': 'never',
        'number-no-trailing-zeros': true,
        'string-quotes': 'single',
        'unit-no-unknown': true,
        'value-no-vendor-prefix': true,
        'property-no-vendor-prefix': true,
        'declaration-no-important': true,
        'declaration-block-no-duplicate-properties': true,
        'declaration-block-semicolon-newline-after': 'always-multi-line',
        'declaration-block-semicolon-newline-before': 'never-multi-line',
        'declaration-block-semicolon-space-after': 'always-single-line',
        'declaration-block-semicolon-space-before': 'never',
        'declaration-block-trailing-semicolon': 'always',
        'block-closing-brace-newline-after': 'always',
        'block-no-empty': true,
        'block-opening-brace-newline-after': 'always'

    }
};

var sassOptions = {
    errLogToConsole: true,
    outputStyle: 'expanded'
};



function css_min() {
    var processors = [cssnano()];
    return gulp.src(paths.css.minCss)
        .pipe(postcss(processors))
        .pipe(gulp.dest(paths.css.cssDir));
}

function css_create_min() {
    return gulp.src(paths.css.concat, { base: paths.css.cssDir })
        .pipe(rename(paths.css.cssMin))
        .pipe(gulp.dest('.'));
}

function css_lint() {
    var processors = [
        stylelint(stylelintConfig),
        reporter({ clearMessages: true })
    ];
    return gulp.src(paths.css.sass)
        .pipe(postcss(processors, { syntax: syntax_scss }));
}

function css_concat() {
    return gulp.src([paths.css.normalize, paths.css.css, '!' + paths.css.minCss], { base: paths.css.cssDir })
        .pipe(concat(paths.css.concat))
        .pipe(gulp.dest('.'));
}

function css_sass() {
    var process = [autoprefixer, focus];
    return gulp.src(paths.css.sass)
        .pipe(sass(sassOptions).on('error', sass.logError))
        .pipe(postcss(process))
        .pipe(gulp.dest(paths.css.cssDir));
}

function css_sass_watch() {
    gulp.watch(paths.css.sass)
        .on('change', gulp.run('css_build'));
}

function copy_libs() {

    return gulp.src(gnf(), {
        base: "./node_modules"
    })
        .pipe(gulp.dest(paths.lib));

}


function js_clean() {
    rimraf(paths.js.concat, cb);
}

function js_min(cb) {
    var options = {
        preserveComments: 'license'
    };
    pump([
        gulp.src(paths.js.minJs, {
            base: './'
        }),
        uglify(),
        gulp.dest('.')
    ], cb);
}

function js_lint() {
    return gulp.src(paths.js.jsFromTsFiles)
        .pipe(jshint())
        .pipe(jshint.reporter(stylish));
}

function js_concat() {
    return gulp.src(paths.js.jsFromTsFiles)
        .pipe(concat(paths.js.concatName))
        .pipe(gulp.dest(paths.js.jsDir));
};

function js_create_min() {
    return gulp.src([paths.js.concat, "!" + paths.js.minJs], {
        base: './'
    })
        .pipe(rename(function (path) {
            path.basename += ".min";
        }))
        .pipe(gulp.dest("."));


}

gulp.task("js_min", js_min);

gulp.task("js_lint", js_lint);

gulp.task('js_concat', js_concat);

gulp.task('js_create_min', js_create_min);

gulp.task('copy_libs', copy_libs);

gulp.task('js_clean', js_clean);

gulp.task('js_min', js_min);

gulp.task('css_lint', css_lint);

gulp.task('css_sass', css_sass);

gulp.task('css_concat', css_concat);

gulp.task('css_min', css_min);

gulp.task('css_create_min', css_create_min);

gulp.task('css_sass_watch', css_sass_watch);

let css_build = gulp.series('css_lint', 'css_sass', 'css_concat', 'css_create_min', 'css_min');

let js_build = gulp.series('js_lint', 'js_concat', 'js_create_min', "js_min");

let build = gulp.parallel(css_build, js_build, function (done) {
    done();
});

gulp.task('css_build', css_build);

gulp.task('js_build', js_build);

gulp.task('build', build);