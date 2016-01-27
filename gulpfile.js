'use strict';

var gulp = require('gulp');
var watch = require('gulp-watch');
var foreach = require('gulp-foreach');

var config = require('./gulp-config.js')();
var websiteRoot = config.websiteRoot;


/*****************************
 Watchers
*****************************/
gulp.task('Auto-Publish-Css', function () {
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
    );
});