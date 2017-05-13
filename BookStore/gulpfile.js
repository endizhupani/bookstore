/// <binding AfterBuild='minify-css, minify-js' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var uglify = require('gulp-uglify');
var ngAnnotate = require('gulp-ng-annotate');

gulp.task('minify-js', function () {
    return gulp.src("Client/js/*.js")
    .pipe(ngAnnotate())
    .pipe(uglify())
    .pipe(gulp.dest("Client/lib/_app/js"));
});

var cleanCSS = require('gulp-clean-css');
var sourcemaps = require('gulp-sourcemaps');
gulp.task('minify-css', function () {
    return gulp.src('Client/css/*.css')
        .pipe(sourcemaps.init())
      .pipe(cleanCSS({ compatibility: 'ie8' }))
        .pipe(sourcemaps.write())
      .pipe(gulp.dest('Client/lib/_app/css'));
});