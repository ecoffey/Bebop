Bebop is an effort to explore some of the ideas that make Django a flexible and fun web framework using Asp.net and C#

Overview
--------

View: A View maps to one URL and must implement at least one of the http verbs (get, put, post, delete).  This design allows Views to stay concise and targeted.

Template: A .aspx page that contains small snippets of code to render a Result

Like Django, in Bebop a particular web site is really a composition of applications held together with a little bit of config glue.

In Bebop a typical web project serves to host the Templates and config glue.  The web project references class library Applications.  An application is a collection of Views and URL mappings


Bebop integrates with Autofac to create Views to serve requests.
