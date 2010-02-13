Bebop is an effort to explore some of the ideas that make Django a flexible and fun web framework using Asp.net and C#.  The source code can be found at [http://github.com/ecoffey/Bebop](http://github.com/ecoffey/Bebop "github")

# Overview

* Resource: A Resource maps to one URL and must implement at least one of the http verbs (get, put, post, delete).  This design allows Resources to stay concise and targeted.
* Template: This could be anything from asp.net mvc style .aspx pages, to any other templating engine
* Model: This is intentionally left open for people to implement differently.  My recommendation is a combination of NHibernate and FluentNHibernate

Like Django, in Bebop a particular web site is really a composition of applications held together with a little bit of config glue.

In Bebop a typical web project serves to host the Templates and config glue.  The web project references class library Applications.  An application is a collection of Resources and URL mappings

Bebop embeds Autofac to automatically create Dependency Injected Resources to serve up Requests.  Bebop Applications are also given a chance to register things in the container when the app first loads.  This allows Resources to just declare what they need from Context and get on with life.

