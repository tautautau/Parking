var ts = require('gulp-typescript');
var less = require('gulp-less');
var gulp = require('gulp');
var clean = require('gulp-clean');
var sourcemaps = require('gulp-sourcemaps');
var merge = require('merge-stream');

gulp.task('ts', function () {
    var tsProject = ts.createProject('tsconfig.json');
    var tsResult = gulp.src([
            "wwwroot/app/**/*.ts"
    ]).pipe(sourcemaps.init()).pipe(ts(tsProject), undefined, ts.reporter.fullReporter()).once('error', function () { tsSuccess = false; });
    return tsResult.js.pipe(sourcemaps.write()).pipe(gulp.dest("wwwroot/app"));
});

gulp.task('less', function () {
    return gulp.src('wwwroot/css/**/*.less')
        .pipe(less().on('error', function (err) {
            console.log(err);
        }))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('watch.ts', ['ts'], function () {
    return gulp.watch('wwwroot/app/**/*.ts', ['ts']);
});

gulp.task('watch.less', ['less'], function () {
    return gulp.watch('wwwroot/css/**/*.less', ['less']);
});