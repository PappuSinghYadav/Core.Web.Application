import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
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
      </div>

    );
  }
}
function callApi() {
    fetch('https://localhost:7209/username', { method: 'GET', mode: 'no-cors', })
        .then(response => alert(response.json()))
        .then(data => alert(data))
}
