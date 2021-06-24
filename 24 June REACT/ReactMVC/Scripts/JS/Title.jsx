class RandTitle extends React.Component {
    componentDidMount() {
        var TitleList = ["HomePage", "Business", "E-Cart"];
        var randTitle = TitleList[Math.floor(Math.random() * TitleList.length)]
        document.title = randTitle;
    }
    render() {
        return (
            <div>Random Title</div>
            )
    }
}
React.render(<RandTitle />, document.getElementById("Randomti"));