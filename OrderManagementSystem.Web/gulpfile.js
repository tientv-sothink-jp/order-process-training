// Include gulp
var gulp = require('gulp');
var gulpless = require('gulp-less');

function watchTask() {
    gulp.watch( [
        './wwwroot/less/*.less',
    ], { events: 'change' }, gulp.series(compileLess));
}

function compileLess(cb) {
    gulp.src('./wwwroot/less/*.less')
    .pipe(gulpless())
    .pipe(gulp.dest('./wwwroot/css'));
    cb();
}

// Default Task
exports.default = gulp.task("default", gulp.series(compileLess));
exports.watch = watchTask;