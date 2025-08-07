import { Link } from 'react-router-dom';

const Navbar: React.FC = () => {
  return (
    <nav>
      <Link to="/chat">Chat</Link>
    </nav>
  );
};

export default Navbar;
