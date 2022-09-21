import { Link } from "react-router-dom";
import SubmitButton from "./Buttons/SubmitButton";
import CardFrame from "./CardFrame";
import InputBlock from "./Inputs/InputBlock";
import SectionHeader from "./section/SectionHeader";

type PropsType = {
    forRegister?: boolean;
};

const LoginCard = (props: PropsType) => (
    <CardFrame>
        <SectionHeader text={props.forRegister ? "Register" : "Login"} />
        <form>
            {props.forRegister && (
                <>
                    <InputBlock name="Firstname" inputId="firstName" />
                    <InputBlock name="Lastname" inputId="lastName" />
                    <InputBlock
                        name="Email"
                        inputId="email"
                        inputType="email"
                    />
                </>
            )}
            <InputBlock name="Username" inputId="userName" />
            <InputBlock
                name="Password"
                inputId="password"
                inputType="password"
            />
            {props.forRegister && (
                <InputBlock
                    name="Confirm Password"
                    inputId="confirmPassword"
                    inputType="password"
                />
            )}
            {!props.forRegister && (
                <Link to={"/forgotPassword"} className="forgot_password">
                    Forgot Password?
                </Link>
            )}
            <SubmitButton text="Submit" className="py-2" />
        </form>
    </CardFrame>
);

export default LoginCard;
