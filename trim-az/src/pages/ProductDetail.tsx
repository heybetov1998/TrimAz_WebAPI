import LightGallery from "lightgallery/react";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";

import "lightgallery/css/lightgallery.css";
import "lightgallery/css/lg-zoom.css";
import "lightgallery/css/lg-thumbnail.css";

import lgThumbnail from "lightgallery/plugins/thumbnail";
import lgZoom from "lightgallery/plugins/zoom";
import SquareImage from "../components/UI/Images/SquareImage";
import CardFrame from "../components/UI/CardFrame";
import AuthorInfo from "../components/UI/Author/AuthorInfo";
import Reviews from "../components/UI/Reviews/Reviews";

const ProductDetail = () => (
    <div id="product_detail">
        <div className="container">
            <Row>
                <Column md={4} lg={4} xl={4}>
                    <LightGallery
                        speed={500}
                        plugins={[lgThumbnail, lgZoom]}
                        selector={".product_image"}
                    >
                        <Row>
                            <Column>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/555-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/555-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                            <Column default={4} sm={4} md={4} lg={4} xl={4}>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/1077-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/1077-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                            <Column default={4} sm={4} md={4} lg={4} xl={4}>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/1077-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/1077-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                            <Column default={4} sm={4} md={4} lg={4} xl={4}>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/1077-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/1077-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                            <Column default={4} sm={4} md={4} lg={4} xl={4}>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/1077-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/1077-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                            <Column default={4} sm={4} md={4} lg={4} xl={4}>
                                <div
                                    className="product_image"
                                    data-src={require("../assets/images/1077-500x500.jpg")}
                                >
                                    <SquareImage
                                        img={{
                                            src: require("../assets/images/1077-500x500.jpg"),
                                        }}
                                    />
                                </div>
                            </Column>
                        </Row>
                    </LightGallery>
                </Column>
                <Column md={8} lg={8} xl={8}>
                    <CardFrame>
                        <div className="name_holder mb-4 d-flex justify-content-between align-items-center">
                            <p className="product_name">Product Name here</p>
                            <span className="product_price">120 AZN</span>
                        </div>
                        <p className="product_description">
                            Lorem ipsum dolor sit amet, consectetur adipisicing
                            elit. Dicta sit numquam voluptate laudantium magnam
                            repellat placeat. Vel perspiciatis dignissimos sunt
                            amet beatae aut explicabo reprehenderit illum nulla
                            facilis aperiam, pariatur ipsa nesciunt nemo,
                            quisquam consectetur maxime architecto laudantium,
                            est alias sit veritatis tempore iure! Magni
                            dignissimos culpa ratione reiciendis voluptate.
                        </p>
                        <AuthorInfo
                            className="mt-4 product_seller"
                            author={{
                                id: "sell2",
                                image: {
                                    src: require("../assets/images/profile-picture.png"),
                                    alt: "some seller info",
                                },
                                name: "Aliyar Aliyev",
                            }}
                        />
                    </CardFrame>
                    <Reviews />
                </Column>
            </Row>
        </div>
    </div>
);

export default ProductDetail;
