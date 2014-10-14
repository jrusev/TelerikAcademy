module.exports = function (grunt) {
    grunt.initConfig({
        coffee: {
            compile : {
                files: {
                    'dev/scripts/code.js': 'app/scripts/code.coffee'
                }
            }
        },
        jshint: {
            all: ['Gruntfile.js', 'app/**/*.js', 'dev/**/*.js']
        },
        jade: {
            compile: {
                files: {
                    'dev/index.html': 'app/views/index.jade'
                },
                options : {
                    compress: false
                }
            }
        },
        stylus: {
            compile : {
                files : {
                    'dev/styles/style.css': 'app/styles/style.styl'
                },
                options: {
                    compress: false
                }
            }
        },
        copy : {
            images: {
                files: {
                    'dev/images/mongodb.png': 'app/images/mongodb.png',
                    'dev/images/coffeescript.jpg': 'app/images/coffeescript.jpg'
                }
            }
        },
        connect: {
            options: {
                port: 9578,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: ['dev']
                }
            }
        },
        watch: {
            js: {
                files: ['Gruntfile.js', 'app/scripts/*.js'],
                tasks: ['jshint'],
                options: {
                    livereload: true
                }
            },
            css: {
                files: ['app/styles/**/*.styl'],
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            html: {
                files: ['dev/index.html'],
                options: {
                    livereload: true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
					'dev/**/*.html',
					'<dev/**/*.css',
					'<app/**/*.styl'
				]
            }
        }
    });
    
    grunt.loadNpmTasks('grunt-contrib-coffee');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-jade');
    grunt.loadNpmTasks('grunt-contrib-stylus');
    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-connect');
    grunt.loadNpmTasks('grunt-contrib-watch');
    
    grunt.registerTask('serve', ['coffee', 'jshint', 'jade', 'stylus', 'copy', 'connect', 'watch']);
};