//
//  ButtonsUITests.swift
//  ButtonsUITests
//
//  Created by Glenn Wilson on 8/31/18.
//

import XCTest

func screenshot(activity: XCTActivity) {
    let screenshot = XCUIScreen.main.screenshot()
    let attachment = XCTAttachment.init(screenshot: screenshot)
    attachment.lifetime = XCTAttachment.Lifetime.keepAlways
    activity.add(attachment)
}

class ButtonsUITests: XCTestCase {
        
    override func setUp() {
        super.setUp()
        continueAfterFailure = false
        XCUIApplication().launch()
    }
    
    override func tearDown() {
        super.tearDown()
    }
    
    // For information on grouping tests into substeps with activities
    // See: https://developer.apple.com/documentation/xctest/activities_and_attachments/grouping_tests_into_substeps_with_activities
    // In App Center Test each activity will display as a separate test step with a screenshot taken at the end of the activity. Or, use the screenshot helper to insert the (one) screenshot at the exact point desired in an activity.
    func testActivities() {
        
        let app = XCUIApplication()
        
        let lessButton = app.buttons["Less"]
        let moreButton = app.buttons["More"]
        let resetButton = app.buttons["Reset"]

        // amountLabel from Accessibility Identifier in storyboard
        let amountLabel = app.staticTexts["amount_label_id"]
        
        XCTAssertTrue(resetButton.waitForExistence(timeout: 10))
        XCTAssertTrue(moreButton.waitForExistence(timeout: 10))
        XCTAssertTrue(lessButton.waitForExistence(timeout: 10))
        XCTAssertTrue(amountLabel.waitForExistence(timeout: 10))
        
        // Default screenshot at end of Activity
        XCTContext.runActivity(named: "Reset") { activity in
            resetButton.tap()
            XCTAssertEqual(amountLabel.value as! String, "0")
        }

        XCTContext.runActivity(named: "Up To One") { activity in
            moreButton.tap()
            XCTAssertEqual(amountLabel.value as! String, "1")
            screenshot(activity: activity) // Activity screenshot here, instead of at end
            moreButton.tap()
            XCTAssertEqual(amountLabel.value as! String, "2")
        }

        XCTContext.runActivity(named: "Down To One") { activity in
            lessButton.tap()
            XCTAssertEqual(amountLabel.value as! String, "1")
            screenshot(activity: activity) // Activity screenshot here, instead of at end
            lessButton.tap()
            XCTAssertEqual(amountLabel.value as! String, "0")
        }

    }
    
    // In App Center Test this test will display with no substeps and only one final screenshot
    func testNoActivities() {

        let app = XCUIApplication()
        
        let moreButton = app.buttons["More"]
        
        // amountLabel from Accessibility Identifier in storyboard
        let amountLabel = app.staticTexts["amount_label_id"]
        
        XCTAssertTrue(moreButton.waitForExistence(timeout: 10))
        XCTAssertTrue(amountLabel.waitForExistence(timeout: 10))

        moreButton.tap()
        XCTAssertEqual(amountLabel.value as! String, "1")

        moreButton.tap()
        XCTAssertEqual(amountLabel.value as! String, "2")
    }
    
}
