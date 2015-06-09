var gulp = require('gulp');

gulp.task('default', function() {
  // place code for your default task here
});

gulp.task('jshint', function() {
    return gulp.src('./src/scripts/*.js')
    .pipe(plumber({
        errorHandler: onError
    }))
    .pipe(jshint())
    .pipe(jshint.reporter('default'))
    .pipe(notify({ message: 'JS Hinting task complete' }));
});