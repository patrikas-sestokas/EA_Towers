const express = require('express');
var cors = require('cors');
const app = express();
const port = 4000;
app.use(cors({credentials: true, origin: `http://localhost:5000`, credentials:true}));
app.use(express.static('public'));

app.listen(port, () => {
    console.log(`Server running on ${port}`)
});
