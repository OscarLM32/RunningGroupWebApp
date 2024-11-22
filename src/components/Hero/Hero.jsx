

function Hero(){
    return (
        <div className="py-5 text-center stretch bg-dark text-light rounded-3 m-1">
            <div className="row py-lg-5">
                <div className="col-lg-6 col-md-8 mx-auto">
                    <h1 className="fw-light">Welcome to RunTogether</h1>
                    <p className="lead text-secondary">
                        Discover a vibrant community of runners who share your passion. Whether you're a seasoned marathoner or just starting your journey, connect with groups near you, join events, and achieve your goals together.
                    </p>
                    <p>
                        <a href="/clubs" className="btn btn-primary my-2">Find a Running Club</a>
                        <a href="/events" className="btn btn-outline-light my-2">Explore Upcoming Events</a>
                    </p>
                </div>
            </div>
        </div>

    )
}

export default Hero;