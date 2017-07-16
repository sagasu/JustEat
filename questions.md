#Answers to questions
1) How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.<br />

Unfortunately last month was and still is a really busy period in my life. I am constantly on various meetings or conf calls until late hours; like 2 am or 4 am, and yes it includes working on Saturday and Sunday. Due to that I was writing the solution for this exercise during meetings, not being fully able to provide as good solution as I would like to. It took me probably about 4-5h to write this solution. Again, I believe that it would be much better, and it would require less time if I actually would be able to fully focus on it. Sorry for all the inconvenience, I am more then happy to provide a full explanation during a meeting.<br />

There are multiple things to add to the solution:<br />
a) From a testing point of view:<br />
** I would definitely add some GUI tests, not necessary end to end tests, but tests for front end workflow in headless browser.<br />
** I would add more unit test hardness, checking for example if various return objects are being passed<br />
** I would refactor ConfigurationManager.AppSettings and add it to a wrapper class, so I can have a full control over what is being passed and returned, and I don't rely on app.config.<br />
** I would add test harness for MVC routing - I am currently using the default one, but there should be harness over it already.<br />
** I would refactor NinjectWebCommon class - this is again a default class and I know that it works, but sooner or later someone is going to touch it, and when they do there better be harness over it. Dealing with WebActivatorEx is a nightmare, I really enjoy getting rid of it, because testing it is unnecessary challenge.<br />
** At least one end to end test just to know if it really works.<br />
<br />
b) From a code point of view<br />
** I hate that swagger api client generation is not automated. I really like to have an automated way to build/refresh my clients. Client generator provided by Swagger for C# is a joke.<br />
** I hate having magic strings like "~/Views/Partials/DisplayRestaurants.cshtml" floating in my code. I should add one of t4 generators to statically check if a view exists, and not build paths on my own.<br />
** Pagination and sorting functionality<br />
** Good error handling<br />
** Nice looking UI and good UX :)<br />
<br />
Time required to address it: about 10-12 h<br />
<br />
2) What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.<br />
Nice question :)<br />
I wouldn't call it a most useful feature, but... I was missing string interpolations since a very beginning. I remember that I was using it in perl 17 years ago and I just can't believe what took them so long.<br />

<code>
var name = "Smeagol";
Console.WriteLine($"My name is {name}.");
</code>

3) How would you track down a performance issue in production? Have you ever had to do this?<br />
Oh... heavy lifting stuff.<br />

I was the guy to spend many hours dealing with WinDbg before it was considered cool :) General knowledge from books like "CLR Via C#" and "C# in depth" is useful. I keep most useful comments on my blog:<br />
http://kuebiko.blogspot.co.uk/2012/11/net-crash-dump-debugging.html<br />
http://kuebiko.blogspot.co.uk/2012/11/thread-wait-and-debugging-sitecore.html<br />

There are various tools you can use. It depends on situation. Now days if you have NewRelic or AppDynamics they are very useful.<br />

There is dotMemory and Ants Profiler<br />

Also Visual Studio provides some basic features to track the bottlenecks.<br />

I like to keep some typical benchmarks in PerfMon like these:<br />
http://kuebiko.blogspot.co.uk/2012/11/perfmon-typical-counters.html?m=0<br />
http://kuebiko.blogspot.co.uk/2012/11/usefull-perfmon-counters-for-memory.html<br />

4) How would you improve the JUST EAT APIs that you just used?<br />
I didn't spend that much time with it, and I haven't look at many methods in the API but...<br />
** After receiving lists of restaurants there is no information about what can I do about it. In a way that Restful API should lead me and help me discover what is the next step, this one is not doing it.<br />
** A general problem with Restful APIs is that there is no discovery service. I have no idea what this API is doing, and how to use it. Also, there is no information about how to set headers. If I was not told to set them, I wouldn't know. It makes me wonder if other methods require different headers, or extra/hidden parameters?<br />
** If I was a client requesting such API, I would ask for pagination and sorting perhaps.<br />

5) <br />
