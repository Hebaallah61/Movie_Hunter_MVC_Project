# Movie Hunter Documentation 😀
-Project of MVC in ITI 

## Our Team :relaxed:
  * [Hesham](https://github.com/HeshamHendawi)
  * [Mohammed](https://github.com/hamadasmsm)
  * [Ahmed](https://github.com/AhmedTaha475)
  * [Asmaa](https://github.com/asmaaabdeen)
  * [Heba]( https://github.com/Hebaallah61)
  * [Maha](https://github.com/Maha-Yehia)
  ------------------

Project Parts:
    1.	Project Structure  
    2.	Data base 
    3.	Identity System 
    4.	Admin dashboard
    5.	Movie Website
--------------    
Part Details : 
    1-	Project Structure:
      a.	Set up for program.cs services and middle wares to work with the project
      b.	Add the configuration for appsettings.json file for connection string ,facebook , google , stripe 
      c.	Project is  partitioned into Areas :
          *	AdminDashBoard
          *	Identity
          *	Payment
          *	User: interaction of user with movies and series
          *	Movies and Series area.        
-------------
    2-	Database : 
     Created Database schema , Models and Context 
      a.	Created Reposatory Pattern in C# Interfaces and classes 
------------
    3-	Identity System :
      a.	Scaffolded identity system created
      b.	Register System with normal user 
      c.	External logins with google and facebook 
      d.	Created Roles (“Admin,Normal users”)
      e.	Admin Account Applied Without Register :
          *ID:admin@moviehunter.com	
          *Password:Admin@movie123  
      f.	Normaly any normal or external user is assigned to Normaluser role 
      g.	Ability to Edit user profile and delete the account
-------------
    4-	Admin Dashboard :  
      Only  accessed to Admin Role 
      a.	Created dashboard to CRUD movies , series and episodes 
      b.	Assign user to Role
      c.	Remove user from Role
      d.	CRUD on  Role
      e.	AdminDashboard Template Was Used
      f.	Custom Data annotation were used
      g.	Using Routing and Routing Constraints
-----------
    5-	Movie Website Features: 
     (Only Authenticated user can watch movies and user full system Features)
      a.	User Can choose among 3 plans (Basic,Premium,Pro) and Use Stripe API to mimic Payment 
      b.	Show all movies and all series and every episode available of that series 
      c.	User can add  specific amount of movies based on his Plan 
         * Basic : 2 movies
         * Premium : 6 movies
         * Pro : Unlimited Movies
         * No Plan : No Favorite movies

    If user tries to add more than the given amount for his plan he will be redirected to custom handler Exception page
      d.	Show Favorite Movies and series for Each user and also recommened Movies based on his Favorite Category
      e.	User can add movies and series to his watch list
      f.	Watch Movies and Series Episodes and the ability to Download them if Authenticated
      g.	News Page 
      h.	Handling 404 Errors and unauthorized Errors with custom pages
------------
    6-	Web site Deployed on IIS
