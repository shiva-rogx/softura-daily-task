var Comp1 = React.createClass({
    render: function () {
        return (
            <div>
                <h1>Multi Comp 1</h1>
            </div>
        );
    }
});
React.render(<Comp1 />, document.getElementById("c1"));