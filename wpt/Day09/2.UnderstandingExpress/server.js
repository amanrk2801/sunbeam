const express = require('express')

// create the object of an express
const app = express()

//route 
// method , path
app.get('/user', (request, response) => {
    response.send("Hello From express server")
})

app.post('/user', (req, res) => {
    res.send('user post method')
})

app.put('/user', (req, res) => {
    res.send('user put method')
})

app.delete('/user', (req, res) => {
    res.send('user delete method')
})

app.get('/product', (req, res) => {
    res.send("get products")
})

app.post('/product', (req, res) => {
    res.send('product post method')
})

app.put('/product', (req, res) => {
    res.send('product put method')
})

app.delete('/product', (req, res) => {
    res.send('product delete method')
})

app.listen(4000, 'localhost', () => {
    console.log('express server started at port 4000')
})

