class Jclass extends React.Component {
    render() {
        return (
            <div style={{ color: "red" }}>Content by React Comp</div>
        )
    }
}
React.render(<Jclass />, document.getElementById("comp"));