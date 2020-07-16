# 4chanDownloader

# Projects
The 4chanAPIWrapper is a .NET Library that does the calls to the 4chan API Endpoints. It returns the corresponding Model Classes as a result (ex => Thread Endpoint results in a ThreadModel Class)

The TesterGUI is a simple GUI that uses the 4chanAPIWrapper Library to show and download the content

# Basic Setup
First reference the Library .dll

Then make sure you are adding both of these using's.
```c#
using FourChanAPIWrapper;
using FourChanAPIWrapper.Models;
```

Now you can access the 4chan API with the following snippet
```c#
// create apiHandler object
FourChanApi _api = new FourChanApi();

//get catalog of board
List<CatalogModel> catalog = _api.GetCatalog("g");

// get index aka page of board
IndexModel index = _api.GetPage("g", 1);

// get specific thread
ThreadModel thread = _api.GetThread("g", "76789611");
```

# Example GUI you could make with the API
![EasyScrape](https://github.com/k0rdesii/4chanDownloader/blob/master/showoff.gif)
