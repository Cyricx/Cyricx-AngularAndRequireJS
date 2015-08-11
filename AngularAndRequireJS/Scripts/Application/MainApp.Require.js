//you will have access to the require object, which you can call it's configuration method
require.config({
	/*it has several properties of use
		paths: this is for "aliasing" file paths
			all paths are relative to this file
	*/
	paths: {
		'testing': '../Test', //do not add .js to the end, require will do that for you
		'jquery': '../../bower/jQuery/dist/jquery.min', //require js takes care of the .js
		'angular': '../../bower/angular/angular.min',
		'angularResource': '../../bower/angular-resource/angular-resource.min',
		'angularRoute': '../../bower/angular-route/angular-route.min',
	},

	//SHIM: allows you to shim (or shiv) things together!
	//there are two uses - one, for exports (what does a library create) and the other dependencies
	shim: {
		'angular':{
			exports: 'angular' //angular does NOT support AMD by default, you must declare export
		},
		'angularResource': {
			deps: ['angular']//requireJS will ensure scripts are loaded in order based on dependencies
		},
		'angularRoute': {
			deps: ['angular']
		},
		'jquery': {
			exports: '$'
		}
	},

	//deps: is used to declare a file that must be loaded before all else. This is typically
	//used to hook up angular
	deps: ['./MainApp.Bootstrap']

})