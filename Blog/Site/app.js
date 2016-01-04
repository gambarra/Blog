var app= angular.module('app',['ui.router']);

app.config(function($stateProvider, $urlRouterProvider, cfpLoadingBarProvider))
{
	
	'use strict';
	$urlRouterProvider.otherwise('/index');
	$urlRouterProvider.when('/', '/index');

	var defaultResolver = {
      start: ['appStarter', function (appStarter) {
        return appStarter;
      }]
    };



}