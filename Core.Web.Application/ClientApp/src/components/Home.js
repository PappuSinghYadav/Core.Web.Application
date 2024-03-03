import React, { Component } from 'react';

import Counter from './Counter';

export class Home extends Component {
  static displayName = Home.name;

    render() {
        var myStyle = {
            fontSize:40
        }
    return (
      <div>
            <h1>Authenticate</h1>
            <label>UserName</label>
            <input id="TextBox"></input>
            <p></p>
            <label>UserName</label>
            <input id="TextBox"></input>
            <p></p>
            <button onClick={callApi}>Call API</button>
            <h1 style={myStyle}>www.javatpoint.com</h1>  
      </div>

    );
  }
}
function callApi() {
    fetch('https://localhost:7209/username', { method: 'GET', mode: 'no-cors', })
        .then(response => alert(response.json()))
        .then(data => alert(data))
}
