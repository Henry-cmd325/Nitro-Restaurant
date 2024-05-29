const authService = require('../services/auth.service');

const authenticate = async (req, res, next) => {
    const idToken = req.headers.authorization?.split('Bearer ')[1];
    if (!idToken) {
        return res.status(401).send('Unauthorized');
    }

    try {
        const decodedToken = await authService.verifyToken(idToken);
        req.user = decodedToken;
        next();
    } catch (error) {
        res.status(401).send('Unauthorized');
    }
};

const checkRole = (role) => {
    return (req, res, next) => {
        if (req.user && req.user.role === role) {
            next();
        } else {
            res.status(403).send('Forbidden');
        }
    };
};

module.exports = {
    authenticate,
    checkRole
};
