# A FizzBuzz Implementation

This is a small implementation of FizzBuzz the word game https://en.wikipedia.org/wiki/Fizz_buzz

I was given the task of implementing a get-method for this [FizzBuzz-list](/FizzBuzz.txt)

The solution is based on .Net Core; it several projects: 

* Shared - where the FizzBuz is implemented.
* Consol - to simply run and write the results of the method in a Commandline window.
* Web - project who exposes the method in an api method. (/api/fizzbuzzservice/100)
* Shared.Test - A Test project to test the project

Note! I did not lookup any source before making my implementation. After finding several rules to the game I extended the source.
