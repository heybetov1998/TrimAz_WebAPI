import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import LoginCard from "../components/UI/LoginCard";

const Login = () => (
    <div id="login_page">
        <div className="container">
            <Row className="justify-content-center">
                <Column md={7} lg={6} xl={5}>
                    <LoginCard />
                </Column>
            </Row>
        </div>
    </div>
);

export default Login;
