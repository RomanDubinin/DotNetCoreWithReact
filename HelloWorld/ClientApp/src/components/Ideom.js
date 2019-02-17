import React, { Component } from 'react';

export class Ideom extends Component {
    static displayName = Ideom.name;

    constructor (props) {
        super(props);
        this.state = { ideoms: [], loading: true };

        fetch('api/Ideom/Ideoms')
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
                        <td>{ideom.russianText}</td>
                        <td>{ideom.englishText}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render () {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Ideom.renderIdeomsTable(this.state.ideoms);

        return (
            <div>
                <h1>Ideoms</h1>
                {contents}
            </div>
        );
    }
}
