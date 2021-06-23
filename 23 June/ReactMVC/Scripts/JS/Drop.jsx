class drop extends React.Component {
    desert = [
        {
            value=1,
            text ="Gulab Jamun"
        },
        {
            value=2,
            text ="Basundi"
        },
        {
            value=3,
            text ="Jalebi"
        },
        {
            value=4,
            text ="Ras Malai"
        },
    ]
    render() {
        return (
            <div>
                <h2>List of Items</h2>
                <hr />
                <select>
                    <option>--Pick your choice--</option>
                    {
                        this.desert.map((displaydesert) =>
                            <option title={displaydesert.value} > (displaydesert.text)</option>)
                    }
                   
                    </select>
            </div>
        )
    }
}
React.render(<drop />, document.getElementById("drop"));
