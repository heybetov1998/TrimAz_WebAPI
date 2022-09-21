import { NavLink } from "react-router-dom";
import SubmitButton from "../components/UI/Buttons/SubmitButton";
import CardFrame from "../components/UI/CardFrame";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import SquareImage from "../components/UI/Images/SquareImage";
import InputBlock from "../components/UI/Inputs/InputBlock";
import SectionHeader from "../components/UI/section/SectionHeader";

const UserSettings = () => (
    <section id="user_settings">
        <div className="container">
            <SectionHeader text="User Settings" />
            <Row>
                <Column md={4} lg={4} xl={3}>
                    <CardFrame className="management_bar">
                        <SquareImage
                            img={{
                                src: require("../assets/images/1077-500x500.jpg"),
                            }}
                        />
                        <h4 className="name">Name surname</h4>
                        <CardFrame className="management_options">
                            <ul>
                                <li>
                                    <NavLink
                                        to={"/users/:id/settings"}
                                        className="option_item"
                                    >
                                        Settings
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to={"/users/:id/reservations"}
                                        className="option_item"
                                    >
                                        Reservations
                                    </NavLink>
                                </li>
                                <li>
                                    <NavLink
                                        to={"/users/:id/wishlist"}
                                        className="option_item"
                                    >
                                        Wishlist
                                    </NavLink>
                                </li>
                            </ul>
                        </CardFrame>
                    </CardFrame>
                </Column>
                <Column md={8} lg={8} xl={9}>
                    <form>
                        <CardFrame title="Personal Information">
                            <Row>
                                <Column lg={6} xl={6}>
                                    <InputBlock
                                        inputId="username"
                                        name="Username"
                                        inputValue={"heybetov1998"}
                                    />
                                </Column>
                                <Column lg={6} xl={6}>
                                    <InputBlock
                                        inputId="email"
                                        name="Email"
                                        inputType="email"
                                        inputValue={"heybetov1998@gmail.com"}
                                    />
                                </Column>
                                <Column lg={6} xl={6}>
                                    <InputBlock
                                        inputId="number"
                                        name="Phone Number"
                                        inputValue={"+994507662233"}
                                    />
                                </Column>
                                <Column lg={6} xl={6}>
                                    <InputBlock
                                        inputId="avatar"
                                        inputType="file"
                                        name="Change avatar"
                                    />
                                </Column>
                            </Row>
                        </CardFrame>
                        <CardFrame title="Change Password">
                            <Row>
                                <Column lg={6} xl={4}>
                                    <InputBlock
                                        name="Current Password"
                                        inputType="password"
                                        inputId="currentPassword"
                                    />
                                </Column>
                                <Column lg={6} xl={4}>
                                    <InputBlock
                                        name="New Password"
                                        inputType="password"
                                        inputId="newPassword"
                                    />
                                </Column>
                                <Column lg={6} xl={4}>
                                    <InputBlock
                                        name="Confirm Password"
                                        inputType="password"
                                        inputId="confirmPassword"
                                    />
                                </Column>
                            </Row>
                        </CardFrame>
                        <SubmitButton text="Save Changes" />
                    </form>
                </Column>
            </Row>
        </div>
    </section>
);

export default UserSettings;
