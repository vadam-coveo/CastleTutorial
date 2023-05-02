# Challenge

	The objective of this challenge is to understand how injection works when dealing with multiple intances of the same thing

	Imagine a banking application, where the system is able to connect to 3 databases at the same time 
		- Mastercard
		- Visa
		- Paypal

	There is already some boilerplate defined, there' a DatabaseConnection & DatabaseConfiguration class, and their attached interfaces (check them out). 

	What is expected in this challenge : 
		1 - you should add all required registrations in the Challenge installer (don't add new installers)
		2 - for each part, you are to create a new method in the challenge1demo class, and write to console "before {part#}" and "after {part#}"
		3 - After each part, you are to tryout the application and checkout the logs (simply run)

## Part 1 : Setting up the connection configurations
	You might have noticed that your configuration class expects a connection name. 
	Register 1 configuration for each database configuration and pass it the right name. 
		- For Mastercard, try the inline-dependencies by value
		- For Visa, supply a new config straight in the installer
		- For Paypal, we want to use the IPaypalFactory (to do this, you'll need to specify UsingFactory)

	Also, make sure your demo component is registeed in the installer. 

	- Make challenge1demo depend on the array of available configurations
	- Loop through them, and write their names to console

	If you've done things right, you should see all 3 names. 

## Part 2 Setting up the connections
	
	The customer wants to know all the transactions that occurred across all the databases (regardless of order). 
		- Register instances of IDatabaseConnection (one for each connection)
		- Create a new service called "Collector" and inject all connection instances
		- In the collector, expose 1 method, that will simply loop through all connections and output their GetInstanceName to log. 

	(The collector is to be registered in the ChallengeDemo)

	Pro tip : you should name the connection configurations according to what they represent

## Part 3 Paypal is special
	Great, now let's imagine for a moment that within the same system, we have that 1 very special service needs to do special things, but only with paypal

	Create a new component & service called SpecialElonMuskTreatment, make it depend on IDatabaseConnection, and make sure you are registering the right connection to it. 
	This new service will expose 1 method that will just call GetInstanceName. 
	
	Same as before, inject this ElonMuskTax service in the ChallengeDemo, and write to console the output (you should see paypal)

## Part 4 Banks kicking-in
	In the same system, the customer now wants to add TD bank transactions. This is getting out of hand! 
	To add the cherry on the sundae, since banks are old school, the service needs to call the bank for a code before doing anything!

	- Create a new component (deriving from BaseComponent), call it TDBankConnection, make it implement the service called IDatabaseConnection
	- Create a public method (only in the impl) called "CallBank" where you will simply log "Calling bank"

	This would be a great opportunity to try messing around with https://github.com/castleproject/Windsor/blob/master/docs/startable-facility.md

	If you've done things right the system should adapt automagically : 
		- the collector should take into account this new bank database connection
		- there should be a "calling bank" in the logs BEFORE seing any connection name