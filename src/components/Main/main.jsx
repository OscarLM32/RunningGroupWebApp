import "./main.css"

export default function Main(){
    return(
        <div className="fun-facts-container">
            <h1 className="fun-facts-title">Fun facts about React!</h1>
            <ul className="facts-list">
                <li className="fact-item">
                    <strong>React was created by Facebook:</strong> React was developed by Jordan Walke, a software engineer at Facebook, and was first deployed in Facebook's News Feed in 2011, then later open-sourced in 2013.
                </li>
                <li className="fact-item">
                    <strong>JSX stands for JavaScript XML:</strong> JSX allows you to write HTML-like code inside your JavaScript files. It's not required, but it's highly recommended because it makes your code easier to read and write.
                </li>
                <li className="fact-item">
                    <strong>React is component-based:</strong> In React, everything is a component. Components can be functions or classes, but they allow for reusable and modular pieces of code.
                </li>
                <li className="fact-item">
                    <strong>React Virtual DOM:</strong> React uses a Virtual DOM to efficiently update the real DOM. This is one of the reasons why React is so fast. Instead of re-rendering the entire UI, it makes changes to a virtual representation of the DOM and then updates only the parts that changed.
                </li>
                <li className="fact-item">
                    <strong>React Hooks:</strong> React introduced hooks in version 16.8, which allow you to use state and other React features without writing a class component. The most common hooks are <code>useState</code> and <code>useEffect</code>.
                </li>
                <li className="fact-item">
                    <strong>React is not a framework, but a library:</strong> While it's often compared to frameworks like Angular or Vue, React is a library focused on the view layer of your application, making it highly flexible and not opinionated about other parts of your stack.
                </li>
            </ul>
        </div>
    )
}