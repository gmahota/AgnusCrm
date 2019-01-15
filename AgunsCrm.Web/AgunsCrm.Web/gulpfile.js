var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less"),
    sass = require("gulp-sass");

//gulp.task("less", function () {
//    return gulp.src('Styles/main.less')
//        .pipe(less())
//        .pipe(gulp.dest('wwwroot/'));
//});

// other content removed

gulp.task("sass", function () {
    return gulp.src('Styles/style.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/'));
});
