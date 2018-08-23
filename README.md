# Stripe-Payment-Integration

Stripe Payment gateway is a Third-party Tool. For using this tool in our application we need to integrate stripe code in our Application. First of all for this we have to create an account on stripe. They provide two types of key <b>PublishableKey</b> and <b>SecretKey</b>. 

For integrate stripe, they provide one script which is generate a button for payment. We have to set some mandatory field for request. Also in form tag we have to set response URL, stripe send response to this URL when payment is complete.

![Stripe screen](https://github.com/rajibsahani29/Stripe-Payment-Integration/blob/master/1.png?raw=true "Stripe screen")

We add this script into our page and when you run this page it will generate button for payment.

![Stripe screen](https://github.com/rajibsahani29/Stripe-Payment-Integration/blob/master/2.png?raw=true "Stripe screen")


When we click on this button it will open payment information popup. In this popup you set Name, Description and logo as per your requirement.

![Stripe screen](https://github.com/rajibsahani29/Stripe-Payment-Integration/blob/master/3.png?raw=true "Stripe screen")


After complete the payment, on response URL page, they provide <b>stripeToken</b> in form header.
After that for checking payment status we need to send request to create a charge. For this we need to add <b>Stripe.net.dll</b> to use stripe class library.

![Stripe screen](https://github.com/rajibsahani29/Stripe-Payment-Integration/blob/master/4.png?raw=true "Stripe screen")


In <b>objStripeCharge</b> object you receive all information about the payment.
