/// <binding BeforeBuild='build' Clean='clean' ProjectOpened='scss:watch' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    sass = require("gulp-sass"),
    autoprefixer = require("autoprefixer"),
    cssnano = require("cssnano"),
    postcss = require("gulp-postcss"),
    stylelint = require("stylelint"),
    reporter = require("postcss-reporter"),
    syntax_scss = require('postcss-scss'),
    focus = require("postcss-focus"),
    rename = require('gulp-rename');

var paths = {
    webroot: "./wwwroot/"
};
paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.css";
paths.cssMin = paths.webroot + "css/site.min.css";
paths.sass = './Css/**/*.scss';
paths.normalize = paths.webroot + "lib/normalize-css/normalize.css";
paths.cssDir = paths.webroot + 'css';
paths.jsDir = paths.webroot + 'js';

var stylelintConfig = {
    "rules": {
        "color-hex-case": "lower",
        "font-family-name-quotes": "always-where-recommended",
        "number-leading-zero": "never",
        "number-no-trailing-zeros": true,
        "string-quotes": "single",
        "unit-no-unknown": true,
        "value-no-vendor-prefix": true,
        "property-no-vendor-prefix": true,
        "declaration-no-important": true,
        "declaration-block-no-duplicate-properties": true,
        "declaration-block-semicolon-newline-after": "always-multi-line",
        "declaration-block-semicolon-newline-before": "never-multi-line",
        "declaration-block-semicolon-space-after": "always-single-line",
        "declaration-block-semicolon-space-before": "never",
        "declaration-block-trailing-semicolon": "always",
        "block-closing-brace-newline-after": "always",
        "block-no-empty": true,
        "block-opening-brace-newline-after": "always"

    }
}

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("css:min", ['css:lint', 'sass', 'css:concat', 'css:create_min'], function () {
    var processors = [cssnano()];
    return gulp.src(paths.minCss)
        .pipe(postcss(processors))
        .pipe(gulp.dest(paths.cssDir));
});

gulp.task('css:create_min', ['css:concat'], function () {
    return gulp.src(paths.concatCssDest)
        .pipe(rename(paths.cssMin))
        .pipe(gulp.dest("."));
});

gulp.task("css:lint", function () {
    var processors = [
     stylelint(stylelintConfig),
     reporter({ clearMessages: true })
    ];
    return gulp.src(paths.sass)
      .pipe(postcss(processors, { syntax: syntax_scss }));
});

gulp.task('css:concat', ['sass'], function () {
    return gulp.src([paths.normalize, paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(gulp.dest("."));
});

var sassOptions = {
    errLogToConsole: true,
    outputStyle: 'expanded'
};
gulp.task('sass', ['css:lint'], function () {
    var process = [autoprefixer, focus];
    return gulp.src(paths.sass)
      .pipe(sass(sassOptions).on('error', sass.logError))
      .pipe(postcss(process))
      .pipe(gulp.dest(paths.webroot + 'css'));
});

gulp.task('sass:watch', function () {
    gulp.run('css');
    gulp.watch(paths.sass, ['css']);
});


gulp.task("css", ["css:lint", 'sass', 'css:concat', 'css:create_min', 'css:min']);

gulp.task("js", ['clean:js', 'min:js']);