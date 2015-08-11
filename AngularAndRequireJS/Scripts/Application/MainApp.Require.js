//you will have access to the require object, which you can call it's configuration method
require.config({
	/*it has several properties of use
		paths: this is for "aliasing" file paths
			all paths are relative to this file
	*/
	paths: {
		'testing':'../Test' //do not add .js to the end, require will do that for you
	},


	//deps: is used to declare a file that must be loaded before all else. This is typically
	//used to hook up angular
	deps: ['./MainApp.Bootstrap']

})