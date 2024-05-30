import React, { useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';
import { useEffect } from 'react';

const Home = () => {

    const [articles, setArticles] = useState([]);

    useEffect(() => {

        const loadArticles = async () => {
            const { data } = await axios.get('/api/scraping/scrapescoop');
            setArticles(data);
        }

        loadArticles();

    }, [])

    return (
        <div className="app-container">
            <div className="d-flex flex-column justify-content-center align-items-center" style={{ marginTop: 11000 }} >
                <h1>These are scraped articles</h1>
                {articles.map(item =>
                    <span key={item.title}>
                        <div className="card" style={{ width: 500 }} >
                            <div className="card-body">
                                <h5 className="card-title">{item.title}</h5>
                                <img src={item.image} className="card-img-top" alt={item.title} />
                                <h4>{item.date}</h4>
                                <p className="card-text">{item.about}</p>
                                <a href={item.url} className="btn btn-primary">Read more</a>
                            </div>
                        </div>
                    </span>

                )}
            </div>
        </div>
    );
};

export default Home;