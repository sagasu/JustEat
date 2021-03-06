# Answers to questions
## 1 How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add. \

Unfortunately last month was and still is a really busy period in my life. I am constantly on various meetings or conf calls until late hours; like 2 am or 4 am, and yes it includes working on Saturday and Sunday. Due to that I was writing the solution for this exercise during meetings, not being fully able to provide as good solution as I would like to. It took me probably about 4-5h to write this solution. Again, I believe that it would be much better, and it would require less time if I actually would be able to fully focus on it. Sorry for all the inconvenience, I am more then happy to provide a full explanation during a meeting.

There are multiple things to add to the solution:\
a) From a testing point of view:
* I would definitely add some GUI tests, not necessary end to end tests, but tests for front end workflow in headless browser.
* I would add more unit test hardness, checking for example if various return objects are being passed.
* I would refactor ConfigurationManager.AppSettings and add it to a wrapper class, so I can have a full control over what is being passed and returned, and I don't rely on app.config.
* I would add test harness for MVC routing - I am currently using the default one, but there should be harness over it already.
* I would refactor NinjectWebCommon class - this is again a default class and I know that it works, but sooner or later someone is going to touch it, and when they do there better be harness over it. Dealing with WebActivatorEx is a nightmare, I really enjoy getting rid of it, because testing it is unnecessary challenge.
* At least one end to end test just to know if it really works.

b) From a code point of view
* I hate that swagger api client generation is not automated. I really like to have an automated way to build/refresh my clients. Client generator provided by Swagger for C# is a joke.
* I hate having magic strings like "~/Views/Partials/DisplayRestaurants.cshtml" floating in my code. I should add one of t4 generators to statically check if a view exists, and not build paths on my own.
* Pagination and sorting functionality
* Good error handling
* Nice looking UI and good UX :blush:

Time required to address it: about 10-12 h

## 2 What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.
Nice question :)\
I wouldn't call it a most useful feature, but... I was missing string interpolations since a very beginning. I remember that I was using it in perl 17 years ago and I just can't believe what took them so long.

<code>
var name = "Smeagol";
 \
Console.WriteLine($"My name is {name}.");
</code>
 
## 3 How would you track down a performance issue in production? Have you ever had to do this?
Oh... heavy lifting stuff.

I was the guy to spend many hours dealing with WinDbg before it was considered cool :) General knowledge from books like "CLR Via C#" and "C# in depth" is useful. I keep most useful WinDbg commands on my blog: \
http://kuebiko.blogspot.co.uk/2012/11/net-crash-dump-debugging.html \
http://kuebiko.blogspot.co.uk/2012/11/thread-wait-and-debugging-sitecore.html

There are various tools you can use. It depends on situation. Now days if you have NewRelic or AppDynamics they are very useful.<br />

There is dotMemory and Ants Profiler

Also Visual Studio provides some basic features to track the bottlenecks.

I like to keep some typical benchmarks in PerfMon like these:\
http://kuebiko.blogspot.co.uk/2012/11/perfmon-typical-counters.html?m=0 \
http://kuebiko.blogspot.co.uk/2012/11/usefull-perfmon-counters-for-memory.html

## 4 How would you improve the JUST EAT APIs that you just used?

I didn't spend too much time with it, and I haven't look at many methods in the API but...\
* After receiving lists of restaurants there is no information what can I do about it. In a way that Restful API should lead me and help me discover the next step, this one is not doing it.
* A general problem with Restful APIs is that there is no discovery service. I have no idea what this API is doing, and how to use it. Also, there is no information about how to set headers. If I was not told to set them, I wouldn't know. It makes me wonder if other methods require different headers, or extra/hidden parameters?
* If I was a client requesting such API, I would ask for pagination and sorting.

## 5 Please describe yourself using JSON.
```json
{  
   "name":"Mateusz Kopij",  
   "nickname":"Dr Matt",  
   "gender":"Male",  
   "dateOfBirth":"20/01/1983",  
   "location": "World, Planet Earth",  
   "interests":[   
       "Startups",  
       "Information Technology - as a theory of information",  
       "Computer Science - as an engineering and craftsmanship",  
       "Business",  
       "Hacking life ;)",  
   ],  
   "Desires":[    
       "Work with nice people",  
       "Work in a company with a great culture",  
       "Have a good work life balance",  
       "Pushing world forward",  
       "Enjoy my time!"  
   ]  
}  
```

## 6 There was no question number 6 :) 
but.. I have to add it. Guys, it is 21 century. Everyone should have github or gitlab account, sending code in a zipped folder and using platforms like box is really old school - and we are loosing commit history and useful info. Let's use github, let's ask developers to just provide a github link :)
