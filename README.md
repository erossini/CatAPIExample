 # CatAPIExample
The task is to create an application that accepts a category and shows results based on that category.
Here are the two API endpoints that can be used.

- http://thecatapi.com/api/categories/list
- http://thecatapi.com/api/images/get?format=xml&results_per_page={page_count}&category={category_name}

## Acceptance Criteria
**Given** I am a user running the application

**And** I see a list of Categories

**When** I select a Category

**Then** I see images related to that category

## Screenshot
![CatAPI Screenshot](https://github.com/erossini/CatAPIExample/blob/master/Screenshot/CatAPIScreenshot.PNG)

## Some questions
### How long did you spend on the coding CatAPI?
I spent about 2 hours, most of the time reading the `XML` and converting it into a useful `Model` and designing a cool page to show the results.

### What would you change / implement in your application given more time?
At the moment when you select a category from the dropdown list, `javascript` recalls the page with a `category` parameter that it reads from the `select`. I would change this part with a `WebAPI`. This `WebAPI` would return a `json` with the list of cats. `jQuery` with `post` reads this `WebAPI` and dynamically shows the cats. Also, I would create tests to check views and code properly.

### Did you use IOC? Please explain your reasons either way.
I didn't use `IOC` (Inversion of Control) in this project. An interesting thing is `WebClient`: I created a generic wbeclient with `T` to call and read the `WebAPI`. For each `WebAPI` result, I created a representation of the `XML` and a function responsible for receiving the XML representation from the generic `WebClient` and converting this into a more easy-to-use `model`.

### How would you debug an issue in production code?
If you can connect your machine to the IIS in the production enviroment, you can debug the application directly from there. If you can't do that, there are some logs in the code in particular when it calls the API. For generating the logs, I'm using `Log4Net`: the problem with this library is that it is not `async`. For this reason, I have created a library to use `Log4Net` in async cases like this. You can find more detail about it on http://puresourcecode.com/page/psc-log4net-async ([PureSourceCode](http://puresourcecode.com) is my blog).

### What improvements would you make to the cat API?
The first thing is I would make it return `json` instead of `XML`.

### What are you two favourite frameworks for .Net?
`.NET` is THE framework.

### What is your favourite new feature in .Net?
I don't know if we can consider `Xamarin` a feature, but I love it!

### Describe yourself in JSON.
I have created [Enrico.manifest](https://github.com/erossini/CatAPIExample/blob/master/Enrico.manifest) :)
