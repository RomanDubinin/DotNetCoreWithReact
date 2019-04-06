import React, { Component } from 'react';

export class Ideom extends Component {
    static displayName = Ideom.name;

    constructor (props) {
        super(props);
        this.state = { ideoms: [], loading: true };

        fetch('api/Ideom/SelectIdeoms')
            .then(response => response.json())
            .then(data => {
                this.setState({ ideoms: data, loading: false });
            });
    }

    static renderIdeomsTable (ideoms) {
        return (
            <table className='table table-striped'>
                <thead>
                <tr>
                    <th>Eng</th>
                    <th>Rus</th>
                </tr>
                </thead>
                <tbody>
                {ideoms.map(ideom =>
                    <tr key={ideom.id}>
                        <td>{ideom.englishText}</td>
                        <td>{ideom.russianText}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    addIdeomHandler(event){
        console.log(event.target)
        const data = new FormData(event.target);
        fetch('api/Ideom/SaveIdeom', {
            method: 'POST',
            body: data
        })
    }

    render () {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Ideom.renderIdeomsTable(this.state.ideoms);

        return (
            <div>
                <h1>Ideoms</h1>
                <form onSubmit={this.addIdeomHandler}>
                    <input id="englishText" name="englishText" type="text" />
                    <input id="russianText" name="russianText" type="text" />
                    <button>Add</button>
                </form>
                {contents}
            </div>
        );
    }
}
