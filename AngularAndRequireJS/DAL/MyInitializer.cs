using AngularAndRequireJS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularAndRequireJS.DAL
{
    public class MyInitializer: CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            List<TicketCategory> categories = new List<TicketCategory>()
            {
                new TicketCategory { Name = "Feature", IsActive = true },
                new TicketCategory { Name = "Enhancement", IsActive = true },
                new TicketCategory { Name = "Bug", IsActive = true }
            };
            categories.ForEach(x => context.TicketCategories.Add(x));
            context.SaveChanges();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket { Title="0.1.1 Setup Application", TicketCategoryID = 1, 
                    Details = "Create initial web application which will be an empty web application with the Web API and MVC libraries already installed.", 
                    SprintDate = new DateTime(2015, 01, 01, 5, 0 , 0), IsClosed = true  },
                new Ticket { Title="0.2.1 EF Code First", TicketCategoryID = 1, 
                    Details = "Install Entity framework with nuget and setup nuget restore. This will allow individuals that pull the repository down to build and run it.", 
                    SprintDate = new DateTime(2015, 02, 01, 5, 0 , 0), IsClosed = true},
                new Ticket { Title= "0.2.2 EF Code First - Add Models", TicketCategoryID = 2, 
                    Details = "Add the ticket and ticketcategory models that will drive and define the creation of the SQL database. This is the part that makes it \"code first\". We will use data annotations to define our data types.", 
                    SprintDate = new DateTime(2015, 02, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.2.3 EF Code First - Connection", TicketCategoryID = 2, 
                    Details = "Just setting up a basic sql connection string in the web.config that we can reference later in the context.", 
                    SprintDate = new DateTime(2015, 02, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.2.4 EF Code First - Database Context", TicketCategoryID = 2, 
                    Details = "The database context will act like our sql connection. In fact in it's ctor we should specify what the name of the connection string is in the web.config, this is also where we define what collections are accessible. We defined the rules to create our models in the Model files. You can also use the fluent api by overriding the OnModelCreating method. Personally, I prefer to define things in the model where I am able, though it should be noted that I am creating a coupling of my models being built specifically for the entity framework. You can also use the fluent api to define this if you override the OnModelCreating method in the context. This choice should be based on the projects requirement.", 
                    SprintDate = new DateTime(2015, 02, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.3.1 Setup Views", TicketCategoryID = 1, 
                    Details = "Add home controller and index view. This is typically where the bloat begins. This step will automatically pull in jquery, bootstrap, and bootstrap's requirement of glyphicons.", 
                    SprintDate = new DateTime(2015, 03, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.4.1 EF Controllers", TicketCategoryID = 1, 
                    Details = "Here we will setup basic EF controllers with views and accept all the default c# and html. This will all be formatted for bootstrap.", 
                    SprintDate = new DateTime(2015, 03, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.4.2 EF Controllers - Navigation", TicketCategoryID = 3, 
                    Details = "Added navigation to access the new areas of the site.", 
                    SprintDate = new DateTime(2015, 03, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.5.1 Data Initializer", TicketCategoryID = 1, 
                    Details = "Add database initializer. The class it inherits specifically dictates how it works. Examples are: CreateDatabaseIfNotExists<>, DropCreateDatabaseAlways<>, DropCreateDatabaseIfModelChanges<>, MigrateDatabaseToLatestVersion<>, etc. The two drop database ones are useful for initial construction of the application. However, before too long you will be disabling the initialization and using migrations to avoid data loss.", 
                    SprintDate = new DateTime(2015, 04, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.5.2 Data Initializer - Define in web.config", TicketCategoryID = 3, 
                    Details = "In order for the intializer to work, you have to define it in the web.config so that Entity Framework knows what to look for where. Due to the string driven configuration, pay close attention to the namespaces and class names. Also, take note of the attribute disableDatabaseInitialization as that will be disabled after you finish initial construction and start putting real data in the database.", 
                    SprintDate = new DateTime(2015, 04, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.5.3 Data Initializer - Add tickets", TicketCategoryID = 2, 
                    Details = "Be careful how much you seed an application. At some point it'll be more tedious to try to input all of the data as c# objects and it would be better to create an sql script, or use the interface itself. Trust me, this comes from the experience of trying to get the seed data to do too much. Migrations are just around the corner and make future development extremely easy!", 
                    SprintDate = new DateTime(2015, 04, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.5.4 Data Initializer - Disable initializer", TicketCategoryID = 2, 
                    Details = "The intializer is extremely easy to disable. Just change the disableDatabaseInitialization attribute in your web.config to true and you are done with initial construction and seed data!", 
                    SprintDate = new DateTime(2015, 04, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.6.1 Migrations - Enable and run Update", TicketCategoryID = 1, 
                    Details = "Enabling migrations is a great way to allow your database to continue to evolve as the project evolves.", 
                    SprintDate = new DateTime(2015, 04, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.6.2 Migrations - Add new property", TicketCategoryID = 2, 
                    Details = "When you have enabled migrations you can add or remove properties as the application evolves and the business needs change. During each iteration you'll add a new migration for that change.", 
                    SprintDate = new DateTime(2015, 04, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.6.3 Migrations - Add Migration Property", TicketCategoryID = 2, 
                    Details = "By using the add-migration <name>, Entity Framework will analyze the models and look for any new changes. It will then create the C# needed to change the database to match the current code base. It will also provide up and down code so that you can revert the change later if desired. The change will take effect when you run update-database.", 
                    SprintDate = new DateTime(2015, 04, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.6.4 Migrations - Add Migration Remove Property", TicketCategoryID = 2, 
                    Details = "To show that it will handle removing properties as well as new properties, we can comment out that new property and rerun the add-migration <name> and then update-database again.", 
                    SprintDate = new DateTime(2015, 04, 15, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.7.1 Web API - Add api controllers", TicketCategoryID = 1, 
                    Details = "Adding the controllers is very easy with the scaffolding, however, there are several gotchas that we have to deal with in order to get this working well with client side applications like Angular.", 
                    SprintDate = new DateTime(2015, 05, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.7.2 Web API - Json and Circular Reference", TicketCategoryID = 3, 
                    Details = "By default web api returns xml. It is very easy to change that to render JSON instead. Not so easy to handle is the circular reference problem that comes about when working with Entity Framework, most especially when we are using Code First. First off, is simply \"Include\" the nested properties that we want. Web API will make no assumptions about that. Then we can use the JsonIgnore attribute to stop the circular reference.", 
                    SprintDate = new DateTime(2015, 05, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "0.7.3 Web API - Create a JSON Model", TicketCategoryID = 3, 
                    Details = "A better way to handle that, which of course means more code, is to create a JsonModel. Similar to the concept of a ViewModel, this gives us direct control over exactly what is rendered, and is another way to stop circular references.", 
                    SprintDate = new DateTime(2015, 05, 01, 5, 0 , 0), IsClosed = true },
                new Ticket { Title= "1.1 Bootstrap - Add Ipsum and setup footer", TicketCategoryID = 1, 
                    Details = "Bootstrap is a great framework to allow for rapid prototyping or even ease the development of a site. On the surface it seems to be a way to avoid learning CSS. In reality, very rarely will Bootstrap work out of the box. However, it does provide a great base that can speed up building the site. The basics work by providing a class base and then defining modifiers. Like btn and btn-warning.", 
                    SprintDate = new DateTime(2015, 05, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "1.2 Bootstrap - Upgrading and basic effects", TicketCategoryID = 2, 
                    Details = "Nuget can be a great quick solution to pull in frameworks and allow for easy upgrading. Always be careful upgrading frameworks. Remember that typical version patterns are listed as <breaking change version>.<feature/enhancement>.<bugfix> So upgrading from 1.0.0 to 2.0.0 will certainly cause a break. Bootstrap also has several helper classes that allow you to quickly add effects or colors to text where needed.", 
                    SprintDate = new DateTime(2015, 05, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "1.3 Bootstrap - Offset and Pull", TicketCategoryID = 2, 
                    Details = "Bootstrap's grid system is built on a very common pattern of 12 that most other frameworks will follow as well. Bootstrap also allows you to offset or pull grid columns. This can be confusing and it's best to play around with the classes as well as check out what css is being applied in a browser's inspector.", 
                    SprintDate = new DateTime(2015, 05, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "1.4 Bootstrap - Tabs", TicketCategoryID = 2, 
                    Details = "Bootstrap comes with a pre-built javascript UI. The javascript will automatically watch for certain attributes and apply effects when it sees them. That means you just have to stick to a common pattern and Bootstrap will take care of the rest!", 
                    SprintDate = new DateTime(2015, 05, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.1 Angular Intro - Web Bundling and Angular", TicketCategoryID = 1, 
                    Details = "Asp.NET's web bundling can make life a lot easier when dealing with a lot of files. It's pretty easy to implement, though there is a gotcha when dealing with Angular.js and minification.", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.2 Angular Intro - Testing Angular", TicketCategoryID = 2, 
                    Details = "When dealing with any new framework you want to be sure to run it through a simple test before you get too deep. It'll help make sure you have everything wired up right and ready to go.", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.3 Angular Intro - Data-Binding", TicketCategoryID = 2, 
                    Details = "Data-Binding is extremely powerful on the client side. Especially when the framework handles adjusting everything that depends on that same value. This would be a LOT of code with something like jQuery. Not only does Angular handle the two-way databinding, it does it so effeciently that it creates a seamless experience for the user.", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.4 Angular Intro - Dependency Injection", TicketCategoryID = 3, 
                    Details = "Dependency Injection is a topic that is beyond the scope of this tutorial. The key benefit you get from Dependency Injection is testability. No, I don't mean the ability for a tester to go through the site clicking on each button and trying everything. I mean the ability for a program to run and tell you whether your code did what you wanted it to do. That automated testing is only possible with Dependency Injection. However, Web Bundling can play havoc if you don't write your Angular files to be prepared for it.", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.5 Angular Intro - Routing", TicketCategoryID = 2, 
                    Details = "Routing in Angular really allows an application to grow, and for users to be able to return to a previous visited page, without having to dive back through the whole interface. It's not much different that a server side routing system, however, since it is all running in the browser it is significantly faster!", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "2.6 Angular Intro - Navigation", TicketCategoryID = 2, 
                    Details = "Angular uses the hash to navigate around and keep the browser happy. You can also enable html5 mode, which will make use of the History API, it does take some server tweaking, which unfortunately is outside of the scope of this tutorial. Here we will use the default mode and a little bit of Bootstrap to create an internal navigation.", 
                    SprintDate = new DateTime(2015, 06, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "3.1 Tickets - Setup Controller and Route", TicketCategoryID = 1, 
                    Details = "Taking advantage of our routing system, we can start to handle separate sections of a site. For example a section to deal with agile Tickets. We will lay the foundation here and this is where we will start to bounce around a lot. However, reptition of the pattern will eventually help us get comfortable.", 
                    SprintDate = new DateTime(2015, 06, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "3.2 Tickets - Services", TicketCategoryID = 2, 
                    Details = "As Angular is an MVC-ish framework, it abides by the separation of concerns principles. Services are singleton objects that are used to share information between controllers, or even site wide. They are commonly used to be the client side equivalent of a repository and handle the inserting, retrieving, updating and deleting of all data.", 
                    SprintDate = new DateTime(2015, 06, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "3.3 Tickets - Resource", TicketCategoryID = 2, 
                    Details = "Angular is built with a \"give you only what you need\" approach that let's you keep the framework small. However, that means to do something new, you will likely have to download another module and wire it up. The resource module is made for communicating with RESTful apis. We will use this to communicate with our Web API.", 
                    SprintDate = new DateTime(2015, 06, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "3.4 Tickets - Directives", TicketCategoryID = 2, 
                    Details = "Directives are more powerful in Angular then I can hope to impress about you in the short amount of time we have. Suffice to say that they are the reusability of your html components. The ng-repeat will give you a hint. Directives can be a fully functional separated piece of your application. Think of them as plug and play components.", 
                    SprintDate = new DateTime(2015, 06, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "3.5 Tickets - Filters", TicketCategoryID = 2, 
                    Details = "Filters allow you to parse or format data or objects before rendering them. You can use them to interrupt the flow of data and modify it mid-stream. This can be from a property to printing it out, or even interrupt data from a controller before it gets to the directive.", 
                    SprintDate = new DateTime(2015, 06, 15, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.1 Tickets CRUD - Quick Close", TicketCategoryID = 1, 
                    Details = "CRUD functionality is a vital part of any application. Angular can significantly speed that up by only passing the data for the requests. There is no huge page reload. Not even a partial page reload. Just the data is sent back and forth and angular's databinding, updates the page. Using our Service and the Resource module, we can quickly hook up the tickets to be easy to close in the blink of an eye.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.2 Tickets CRUD - Another Controller", TicketCategoryID = 2, 
                    Details = "Angular tends to follow more of an MVVM pattern. The controllers are more of a ViewModel and handle the interactions between the views and the models. A Different view, typically means a different controller.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.3 Tickets CRUD - Getting from Route and Resource", TicketCategoryID = 2, 
                    Details = "Angular's routing gives you easy access to the parameters you specify which can be used in combination with the resource module to quickly retrieve a specific item. Binding to the inputs can be a bit troublesome when dealing with dates due to JSON's use of timezones.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.4 Tickets CRUD - FK Selects", TicketCategoryID = 2, 
                    Details = "Adding dropdown lists or html select elements, for a foreign key value is pretty easy with angular. Once again due to the directives. For those that are used to jQuery and wanting to keep their html clean, Angular breaks that rule by writing a lot of things \"inline\". However, by doing so they keep things in one spot to read and maintain a separation of concerns through the use of directives.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.5 Tickets CRUD - Updating", TicketCategoryID = 2, 
                    Details = "Implementing an update is super simple since we already added the functionality to the TicketService. This is where separation of concerns start to really help out. It helps us reuse components if they aren't embedded inside of other components.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.6 Tickets CRUD - Creating", TicketCategoryID = 2, 
                    Details = "With a few modifications, we can get the create rolling too. Since the Resource allows us to override it's configuration we can use it for any RESTful api, regardless of what pattern they use. A few small tweaks and we have separated the POST and PUT methods so that the Web API will work just fine out of the box!", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "4.7 Tickets CRUD - Fixing Category Issue", TicketCategoryID = 3, 
                    Details = "One of the downside of including the full TicketCategory object inside of the Ticket object that gets returned from WebAPI is that the TicketCategoryID's won't match up. However, if we reset the nested object to undefined then EntityFramework won't check for integrity and will just assume it's updating one that didn't have a category.", 
                    SprintDate = new DateTime(2015, 07, 01, 5, 0 , 0), IsClosed = false },
                new Ticket { Title= "Finished!!", TicketCategoryID = 1, 
                    Details = "As with all frameworks, there is a learning curve. However, you should always choose the framework based on the need of the organization and the most effecient way to deliever the content to the user. Angular thrives as an admin interface, allowing individuals to sort through large amounts of data, and load it incredibly fast due to only transfering the data itself. The only downside with Angular is SEO.", 
                    SprintDate = new DateTime(2015, 07, 22, 5, 0 , 0), IsClosed = false }
            };
            tickets.ForEach(x => context.Tickets.Add(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}