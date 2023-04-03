
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

## Project Parts:
1.	Project Structure  
2.	Data base 
3.	Identity System 
4.	Admin dashboard
5.	Movie Website
--------------  

## Part Details:
1. Project Structure:
    1. Set up for program.cs services and middle wares to work with the project
    2. Add the configuration for appsettings.json file for connection string ,facebook , google , stripe
    3. Project is  partitioned into Areas:
       1. AdminDashBoard
       2. Identity
       3. Payment
       4. User: interaction of user with movies and series
       5. Movies and Series area.  

-------------

 2.	Database : 
   1. Created Database schema , Models and Context 
      * Created Reposatory Pattern in C# Interfaces and classes 
------------

 3.	Identity System :
      1.	Scaffolded identity system created
      2.	Register System with normal user 
      3.	External logins with google and facebook 
      4.	Created Roles (“Admin,Normal users”)
      5.	Admin Account Applied Without Register:
          1. ID:admin@moviehunter.com	
          2. Password:Admin@movie123  
      6.	Normaly any normal or external user is assigned to Normaluser role 
      7.	Ability to Edit user profile and delete the account
-------------

 4. Admin Dashboard :  
      Only  accessed to Admin Role 
      1.	Created dashboard to CRUD movies , series and episodes 
      2.	Assign user to Role
      3.	Remove user from Role
      4.	CRUD on  Role
      5.	AdminDashboard Template Was Used
      6.	Custom Data annotation were used
      7.	Using Routing and Routing Constraints
-----------

 5. Movie Website Features: 
     (Only Authenticated user can watch movies and user full system Features)
      1.	User Can choose among 3 plans (Basic,Premium,Pro) and Use Stripe API to mimic Payment 
      2.	Show all movies and all series and every episode available of that series 
      3.	User can add  specific amount of movies based on his Plan 
         1. Basic : 2 movies
         2. Premium : 6 movies
         3. Pro : Unlimited Movies
         4. No Plan : No Favorite movies

    ### (If user tries to add more than the given amount for his plan he will be redirected to custom handler Exception page)
      4.	Show Favorite Movies and series for Each user and also recommened Movies based on his Favorite Category
      5.	User can add movies and series to his watch list
      6.	Watch Movies and Series Episodes and the ability to Download them if Authenticated
      7.	News Page 
      8.	Handling 404 Errors and unauthorized Errors with custom pages
      
------------

 6. Web site Deployed on IIS
----------

