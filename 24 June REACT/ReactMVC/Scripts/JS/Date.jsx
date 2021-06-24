class DateComp extends React.Component {
    componentDidMount() {
        var str = "ReactPage";
        //document.title = str;
    }

    render() {
        var dtime = new Date();
        var CurrDate = dtime.toDateString();
        var CurrTime = dtime.getHours() + ":" + dtime.getMinutes() + ":" + dtime.getSeconds();
        return (
            <div>
                <h3>{CurrDate} - {CurrTime}</h3>
                <title>MyTitle</title>
            </div>
        )
    }
}
React.render(<DateComp />, document.getElementById("D1"));
