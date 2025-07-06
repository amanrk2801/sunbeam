# React

## Single Page Application (SPA)

- a application that loads a single HTML page and dynamically updates that page as the user interacts with the app
- to develop SPAs,
  - we need to use a JavaScript framework or library
  - like
    - React
    - Angular
    - VueJs
- advantages
  - fast: similar performance to native apps
  - responsive: the app responds to user interactions (browser size changes),
    - to make the app responsive
      - we need to use CSS media queries
      - frameworks: bootstrap, tailwind
  - user-friendly

## functional programming language

- function is considered as first class citizen
  - function is created as a variable of type function
- function can be passed as an argument to another function
- function can be returned from another function as return value

## function reference

- a reference to a function
- a variable that holds a function body's address

```javascript
// here the function1 is a function reference
// to the function body
function function1() {
  console.log('inside function1')
}
```

## React

- a JavaScript library for building user interfaces

## React vs Angular

- React is a Library (developed in JS) and Angular is a Framework (developed in TypeScript)
- react development and performance is faster than angular
  - to make it faster, react uses a virtual DOM
  - it also has less memory consumption/footprint
- React has less learning curve than Angular

## important points

- do not use `class` as it is a reserved keyword in JavaScript, use `className` instead
- interpolation is done using `{}` in JSX
- interpolation always requires a scalar value and CAN NOT render an object

## virtual DOM

- a lightweight copy of the real DOM (browser DOM) (document object)
- react uses virtual DOM to improve performance
- when we update the state of a component, react creates a new virtual DOM and compares it with the previous virtual DOM
- then it updates only the changed parts of the real DOM
- this process is called reconciliation

## environment setup

- using CDN links

  - CDN: content delivery network
  - add react using CDN links

  ```html
  <html>
    <head>
      <!-- used for react development -->
      <script
        crossorigin
        src="https://unpkg.com/react@18/umd/react.development.js"
      ></script>

      <!-- used for react virtual dom development -->
      <script
        crossorigin
        src="https://unpkg.com/react-dom@18/umd/react-dom.development.js"
      ></script>
    </head>

    <body>
      <div id="root"></div>
    </body>
  </html>
  ```

  - to create element use a function called `createElement`

    ```javascript
    // create element
    // React is an object which will be used to create elements
    // this object is provided by react library (react.development.js)

    // parameters
    // 1st: name or type of the element (e.g. h1, h2 etc)
    // 2nd: attributes or properties of the element (e.g. class, id, style etc). this must be an object.
    // 3rd: contents of the element (e.g. text, html etc)
    const h2 = React.createElement('h2', {}, 'hello world')

    // React 17 style of rendering an element
    // get the root element
    // this is the element where we will render our react elements
    // const root = document.getElementById('root')

    // render the element
    // ReactDOM.render(h2, root)

    // React 18 style of rendering an element

    // create a root element
    const root = ReactDOM.createRoot(document.getElementById('root'))

    // render the element
    root.render(h2)
    ```

  - to create an element using JSX, use babel

    ```html
    <html>
      <head>
        <!-- used for react development -->
        <script
          crossorigin
          src="https://unpkg.com/react@18/umd/react.development.js"
        ></script>

        <!-- used for react virtual dom development -->
        <script
          crossorigin
          src="https://unpkg.com/react-dom@18/umd/react-dom.development.js"
        ></script>

        <!-- babel compiler -->
        <script src="https://unpkg.com/@babel/standalone/babel.min.js"></script>
      </head>

      <body>
        <div id="root"></div>
        <script type="text/babel">
          const h2 = <h2>hello world</h2>
          const root = ReactDOM.createRoot(document.getElementById('root'))
          root.render(h2)
        </script>
      </body>
    </html>
    ```

- using package manager like vite

## JSX

- a syntax extension for JavaScript
- allows you to write HTML code inside JavaScript
- how does it work?

  - babel is used to convert JSX code into JavaScript code
  - babel is a JavaScript compiler

  ```html
  <script type="text/babel">
    // JSX code
    const h2 = <h2>hello world</h2>

    // babel converts the above code into the following code
    // const h2 = React.createElement('h2', {}, 'hello world')
  </script>
  ```
