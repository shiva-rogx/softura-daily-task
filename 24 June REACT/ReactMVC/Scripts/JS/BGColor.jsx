

class Bgcolor extends React.Component {
    render() {
        const mystyle = {
            color: "black",
            backgroundColor: "DodgerBlue",
            padding: "5px",
            fontFamily: "Times New Roman"
        };
        return (
            <div>
                <h2 className="component"> Style</h2>
            </div>
            )
    }
}
React.render(<Bgcolor />, document.getElementById("sty"));