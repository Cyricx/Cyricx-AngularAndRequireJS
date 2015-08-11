/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    //Configuration setup
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        sass: {
            dist: {
                files: {
                    'content/site.css': 'sass/site.scss'
                }
            }
        },
        watch: {
            scripts: {
                files: ['sass/*.scss'],
                tasks: ['sass']
            }
        }
    });
    //load npm tasks
    grunt.loadNpmTasks('grunt-sass');
    grunt.loadNpmTasks('grunt-contrib-watch');

    //register tasks
    grunt.registerTask('process', ['sass', 'watch']);
    grunt.registerTask('default', ['sass']);
};