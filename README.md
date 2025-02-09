# word-bank-generator

## filters
- length
  - range and exact
- starting letter
- plural or not
- contains letter or substring
- category/type (i.e. location, verb, adverb, pronoun, article)
- flag for exclusion of proper nouns life names and locations if desired
- origin (i.e. latin, greek, etc.)
- number of words

## general rules for the word db
- no acronyms with few exceptions (ie. scuba and laser are ok)
- for the most part, no foreign words in each respective language's database. (ex. in english, jalapeno, croissant, kindergarten are ok.)
- location names are valid as long as they are in each respective language (i.e. germany is ok, deutschland is not)

- grey area words that we need to think of rules for:
  - tijuana
  - ...

## Usage

To use the word bank generator, make a GET request to the `/wordbank` endpoint with the desired query parameters. The available query parameters are:

- `startsWith`: Filter words that start with the specified letter or substring.
- `length`: Filter words by their exact length.
- `isPlural`: Filter words based on whether they are plural or not (true/false).
- `contains`: Filter words that contain the specified letter or substring.
- `category`: Filter words by their category/type (e.g., location, verb, adverb, pronoun, article).
- `excludeProperNouns`: Exclude proper nouns like names and locations if set to true.
- `origin`: Filter words by their origin (e.g., Latin, Greek, etc.).
- `numberOfWords`: Limit the number of words returned.

Example request:

```
GET /wordbank?startsWith=a&length=5&isPlural=false&contains=e&category=fruit&excludeProperNouns=true&origin=latin&numberOfWords=10
```

This request will return up to 10 words that start with "a", have a length of 5 characters, are not plural, contain the letter "e", belong to the category "fruit", exclude proper nouns, and have a Latin origin.

## Running the app locally

To run the app locally for testing, follow these steps:

1. Clone the repository:
   ```
   git clone https://github.com/mpchenette/word-bank-generator.git
   ```

2. Navigate to the project directory:
   ```
   cd word-bank-generator
   ```

3. Restore dependencies:
   ```
   dotnet restore
   ```

4. Build the project:
   ```
   dotnet build
   ```

5. Run the project:
   ```
   dotnet run
   ```

