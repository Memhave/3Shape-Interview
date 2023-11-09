# 3Shape API

## How to run

This was built in VSCode, so just press debug, although on Visual Studio / Rider you might need to set up `launchOptions.json`.

## Questions:

1. In the job description, it was mentioned that you wanted "hard to change / modify" software -> is this a mistake in the wording? 

If not, I would like to know why :)

2. Can a new part of scan that overlaps deviate in the overlap section?

Example: 1abc adc2 (total overlap between 1 & 2), would this be legal?

3. Was it expected to implement auth/persistence? 

I think I would have implemented persistence but more for fault tolerance in case one of the other parts went down (case, the image receiver).

## Notes:

I decided to implement onion architecture as I thought it could be a good fit, another good fit is probably ports / adapters due to the nature of needing different ports (scanner / reconstruction receiver).

Also used VSCode for the first time, so some formatting is off. 

I found the brief really good and it was quite an interesting problem.

## Things I deciced not to do / complete 

1. Auth,

Did not see the value in this because sometimes its tricky set up quickly (in my experience)

2. Persistence,

Same as auth, probably could have just done dapper + sqlite but not much more value than in memory, didnt need it for unit test

3. Integration test/fixture

Can be time consuming to set up

4. Validation

Was not scoped in the task, but could have done some `IValidatableObject`. Lots of ways to do validatation

5. Full implementation of ReconstructionEntity

This was probably possible in the time, but I think I left enough notes to show that I understood it.

6. Case creation

I was not sure about this requirement it simply wanted another endpoint or some sort of webhook/push type action (like email)

7. Startup file

Just configuration

8. Containerisation

Did not have docker set up and to me its not an implementation detail but infra / config




# Initial brief
 Introduction

(standard image of teeth with numbers)

Dentists use different numbering systems to identify teeth. One of these, the Universal Numbering System (UNS), numbers teeth from 1 through 32 going from the upper right molar furthest back to the opposite molar on the lower jaw.

A black background with a black square Description automatically generated with medium confidence

At TRIOS reconstruction, we handle incoming images of teeth, acquired when the dentist uses our scanner, and assemble these into a full 3D model. We do so one jaw at a time, so we only expect the dentist to scan either the upper or lower jaw at a time. A different team uses our API by passing incoming images, and provides additional tooling to work with the reconstructed model, such as marking specific teeth on the model for preparation and subsequent restoration. For the purpose of this assignment, you will act as an intermediary, and be designing/writing code for both teams.

Let's assume that incoming images are strings of text, a proxy for the real data we receive to simplify this assignment. These strings are a subset of the full model to be reconstructed. Each incoming image usually contains a distinguishing visual element, which we will represent as the UNS number. An example of a successful partial reconstruction of the upper jaw could be "1oene2enoe3neoo4aei5iia", in which "1oene" represents the third molar in the upper right quadrant. An incoming image is 5 characters, e.g., "ne2en". Subsequent incoming images can be assumed to always overlap with previously scanned areas.

The letters represent the geometry of the teeth. The quality of the geometry in the images isn't always perfect, and you may receive images which deviate from the "ground truth". For example: "1ofne" deviates from "1oene" by a "distance" of 1, since "f" is one character away from "e".

Task description

Create a code skeleton and/or diagrams to support the following features. And, provide implementations to parts you find relevant (C# is recommended if you are familiar with it).

§  Receive images from the scanner and forward them to the reconstruction engine.

§  Return the currently reconstructed model from the reconstruction engine, e.g., "1oene2enoe3neoo4aei5iia" described in the introduction.

§  Allow trimming away previously scanned sections from the reconstruction model, i.e., reset what was previously scanned. E.g., remove "ne2en" from the string above.

§  Get the geometry of a specific tooth from a reconstructed model. E.g. return "1oene" when the upper right molar furthest in the back is requested.

§  Create a case to be sent to a lab with a tooth marked for a specific restoration.

You can approach this problem aligned with your preferred way of working. We don't expect a completely functional nor "perfect" solution. Instead, we suggest you spend 1-2 hours on the task and prioritize your work as you normally would when tackling a similar problem. Send us the output of your work (source files, diagrams, analysis, important questions) prior to the interview. A GitHub repository invite would be preferred. Be prepared to discuss parts of the solution you did not get around to work on.

 