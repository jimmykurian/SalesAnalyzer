module.exports = {
    roots: ['<rootDir>/src'],
    preset: 'ts-jest',
    globals: {
      'ts-jest': {
        diagnostics: true,
      },
    },
    collectCoverageFrom: [
      'src/**/*.{js,jsx,ts,tsx}',
      '!src/**/*.d.ts',
      '!src/serviceWorker.ts',
      '!src/setupTests.ts',
      '!src/index.tsx',
    ],
    coveragePathIgnorePatterns: ['./src/*/*.types.{ts,tsx}'],
    coverageReporters: ['json', 'lcov', 'text-summary', 'clover'],
    coverageThreshold: {
      global: {
        statements: 95,
        branches: 95,
        lines: 95,
        functions: 95,
      },
    },
    snapshotSerializers: ['enzyme-to-json/serializer'],
    testMatch: ['<rootDir>/src/**/*.test.{js,jsx,ts,tsx}'],
    automock: false,
    transform: {
      '^.+\\.(js|jsx|ts|tsx)$': '<rootDir>/node_modules/ts-jest',
    },
    transform: {
      '^.+\\.(js|jsx|ts|tsx)$': '<rootDir>/node_modules/ts-jest',
    },
    modulePaths: [],
    moduleNameMapper: {
      '^react-native$': 'react-native-web',
      "\\.(css|less|sass|scss)$": "<rootDir>/jest.styles.stub.js",
      'src/(.*)$': '<rootDir>/src/$1',
    },
    moduleFileExtensions: ['ts', 'tsx', 'js', 'jsx', 'json', 'node'],
  };