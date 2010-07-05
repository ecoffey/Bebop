# Introduction

Bebop is a opinionated .Net web framework.  It currently lives at [http://github.com/ecoffey/Bebop](http://github.com/ecoffey/Bebop "github").

# The Opinions

It makes two key decisions to quickly get a project off the ground:

* Autofac :  Bebop is built on the excellent Inversion of Control Container, Autofac.
* NHaml :  NHaml is a .Net port of the Haml markup language.  It helps to keep views clean, concise and obvious.

# The Players

* Resource : A Resource is a class that represents, well, a Resource!  It must implement at least one of the HTTP Verbs (Get, Put, Post, Delete) to really be useful to anyone.  Furthermore because Bebop is built on Autofac when a request comes in the Resouce to handle it is resolved by the IoC Container.  This means
a Resource can just declare what it needs to get work done and get on with life.

* Application : In Bebop an Application is a collection of related Resources, and also where URLs are mapped to the Resource that will handle them.  Again, Autofac is leveraged so that when an Application is loaded all the Resources are automatically registered in the Container, and the Application itself can register needed dependicies as well.

* Project : The Project in Bebop is the actual Website.  It is where Applications are loaded and rooted at a particular URL, and where the Views live.

