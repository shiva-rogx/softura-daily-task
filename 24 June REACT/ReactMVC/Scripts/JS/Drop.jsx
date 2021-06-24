Foods = [
    {
        value: 1,
        item: 'Pizza'
    },
    {
        value: 2,
        item: 'Momos'
    },
    {
        value: 3,
        item: 'Briyani'
    },
    {
        value: 4,
        item: 'Burger'
    },
]
var items = Foods.map(food => {
    console.log(Foods)
    return (
        <option>{food.item}</option>
    )
})
var Myapp = React.createClass({
    render: function () {
        return (
            <div>
                <select>
                    {items}
                </select>
            </div>
        )
    }
});

React.render(<Myapp />, document.getElementById("drop-div"));