'use strict';

var gulp = require('gulp');
var watch = require('gulp-watch');
var foreach = require('gulp-foreach');
var browserSync = require('browser-sync').create();

var config = require('./gulp-config.js')();
var websiteRoot = config.websiteRoot;


/*****************************
 Watchers
*****************************/
gulp.task('watch-css', function () {
    var roots = './OscarMayer/assets';
    var files = '/*.css';
    var destination = websiteRoot + '\\assets';

    console.log(roots);

    gulp.src(roots).pipe(
      foreach(function (stream, rootFolder) {
          gulp.watch(rootFolder.path + files, function (event) {

              if (event.type === 'changed') {
                  console.log('Publish this file ' + event.path);
                  gulp.src(event.path, { base: rootFolder.path }).pipe(gulp.dest(destination));
              }

              console.log('Published ' + event.path);
          });
          
          return stream;
      })
    ).pipe(browserSync.stream());
});

gulp.task('browser-sync', ['watch-css'], function () {
    var destination = websiteRoot + '\\assets\\*.css';
    browserSync.init({
        proxy: config.host
    });

    gulp.watch(destination).on('change', browserSync.reload);
});