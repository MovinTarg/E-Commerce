For this assignment, we are going to be building a virtual storefront as a sort of capstone project. It will be a site that displays listings of products for sale with the ability to dive into each of the individual product pages to have access to more information. From there, products will be able to be added to a cart and also purchased. Following the wireframe below try to replicate the functionality of an E-commerce website. Be sure to take into mind all the things you've learned up until now including taking web security feature into mind!

   

Stripe API
So as an extra piece to this assignment we highly encourage that you attempt to work with Stripe API as well when building out the app. Stripe is an API meant to help with Ecommerce site construction by providing services for billing, carts, product info, customers, and order history. This is awesome for our purposes! With Stripe the first thing we need to do is create an account on their site so that we can get an API key.

Head to their website here
Create a new account
Navigate to Your Account > Account Settings > API Keys
Here you'll find the keys you need!
Once you have that in place there is a great package for working with Stripe in ASP.NET called Stripe.Net (https://github.com/jaymedavis/stripe.net). This will provide us most hooks and methods we'll need when working with stripe features. Documentation for the different methods can be found on their GitHub page. We just need to import the dependencies then configure the service.

project.json

...
"Newtonsoft.json": "9.0.1",
"Stripe.net": "6.8.0"
...
Startup.cs

StripeConfiguration.SetApiKey("[your api key here]");