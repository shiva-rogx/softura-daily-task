var Comp2 = React.createClass({
    render: function () {
        return (
            <div>
                <h1 style= {{ backgroundColor: "blueviolet" }}>Multi Comp 2</h1>
            </div>
        );
    }
});
React.render(<Comp2 />, document.getElementById("c2"));