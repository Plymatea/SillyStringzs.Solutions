# _Hair Salon_

#### By **_Andy Plymate_**

#### _A webpage that allows users to track "Minions" and "Tech" they are trained on. This is a conceptual design and can be expanded easily._

## Technologies Used

* _C#_
* _HTML5_
* _CSS_
* _Razor_
* _Bootstrap_
* _ASP.Net Core_
* _Entity_
* _MVC_

## Description

_This web application can be used to create and track minions. Once a minion (Engineer) has been created you can associate tech (Machines) with each one._

_The application has been designed with expansion in mind and could easily include more minion or tech details/interconnectivity if required._

## Setup/Installation Requirements
* _Requires VSCode and MySql_

* _You can find the github repository [here](https://github.com/Plymatea/SillyStringzs.Solutions.git)_
* _In your preferred terminal, navigate to the directory you would like to store the project_
* _$ `git clone https://github.com/Plymatea/SillyStringzs.Solutions.git`_
* _Now that the repository is cloned to your computer, right click on the folder and click "open with vs code"_

_**In order to access a usable version of the sql database you will need to do the following:**_

* _Create a file named appsettings.json in the Factory directory_
* _The file should contain this block of code except with your own username and password for the server( [ ] brackets around private information not included):_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=to_do_list;uid=[Your Id Goes Here];pwd=[Your Password Here];"
  }
}
```
* _$ `dotnet build`_
* _$ `dotnet ef database update`_

 * _Once all of the above is completed you can view the project on your local server by running "dotnet run"_


## Known Bugs

* _Need to include verification for duplicate MachineEngineer relationships_

## Road Map

* _Edit feature for all classes_

## License - [MIT](https://opensource.org/licenses/MIT)


Copyright (c) _2022_ _Andy Plymate_