import SubmitButton from "../components/UI/Buttons/SubmitButton";
import CardFrame from "../components/UI/CardFrame";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import ContactInput from "../components/UI/Inputs/ContactInput";

const Contact = () => {
    return (
        <section id="contact">
            <div className="container">
                <form>
                    <Row>
                        <Column md={6} lg={6} xl={6}>
                            <div className="contact_information">
                                <h3>Send Feedback</h3>
                                <p>You can send us feedback by filling form</p>
                            </div>
                        </Column>
                        <Column md={6} lg={6} xl={6}>
                            <CardFrame title="Send a message">
                                <Row>
                                    <Column
                                        className="mb-3"
                                        sm={6}
                                        md={12}
                                        lg={6}
                                        xl={6}
                                    >
                                        <ContactInput
                                            type="text"
                                            placeholder="Full name*"
                                        />
                                    </Column>
                                    <Column
                                        className="mb-3"
                                        sm={6}
                                        md={12}
                                        lg={6}
                                        xl={6}
                                    >
                                        <ContactInput
                                            type="email"
                                            placeholder="Email*"
                                        />
                                    </Column>
                                    <Column>
                                        <textarea
                                            className="message mb-3"
                                            placeholder="Message*"
                                            id=""
                                        ></textarea>
                                    </Column>
                                </Row>
                                <SubmitButton
                                    text="Send your message"
                                    className="curved_button"
                                />
                            </CardFrame>
                        </Column>
                    </Row>
                </form>
            </div>
        </section>
    );
};

export default Contact;
